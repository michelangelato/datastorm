package com.datastorm.hackreativityandroid.mvp.repositories;

import android.content.Context;

import com.datastorm.hackreativityandroid.interfaces.ITopicRepository;
import com.datastorm.hackreativityandroid.mvp.entitites.Topic;

import java.util.Date;
import java.util.List;

import io.requery.query.Result;
import rx.Observable;
import rx.Single;

public class RequeryTopicRepository extends RequeryRepository implements ITopicRepository {

	private static final int SECOND_IN_MILLIS = 1000;
	private static final int MINUTE_IN_MILLIS = SECOND_IN_MILLIS * 60;
	private static final int HOUR_IN_MILLIS   = MINUTE_IN_MILLIS * 60;
	private static final int DAY_IN_MILLIS    = HOUR_IN_MILLIS * 24;
	private static final int WEEK_IN_MILLIS   = DAY_IN_MILLIS * 7;

	public RequeryTopicRepository(Context context) {
		super(context);
	}

	@Override
	public Observable<List<Topic>> retrieve() {
		return db().select(Topic.class)
		           .where(Topic.PINNED.eq(true)
		                              .and(Topic.LAST_SUBSCRIBED_TO.greaterThan(lastValidDate())))
		           .get()
		           .toSelfObservable()
		           .map(Result::toList);
	}

	@Override
	public Single<Boolean> upsert(Topic topic) {
		return Single.create(singleSubscriber -> {
			try {
				topic.setLastSubscribedTo(new Date());
				db().upsert(topic);
				singleSubscriber.onSuccess(true);
			} catch (Exception e) {
				singleSubscriber.onError(e);
			}
		});
	}

	@Override
	public Single<Boolean> upsert(String topicName) {
		return Single.create(singleSubscriber -> {
			try {
				Topic topic = new Topic();
				topic.setTopic(topicName);
				topic.setLastSubscribedTo(new Date());
				topic.setPinned(true);
				db().upsert(topic);
				singleSubscriber.onSuccess(true);
			} catch (Exception e) {
				singleSubscriber.onError(e);
			}
		});
	}

	private Date lastValidDate() {
		return new Date(System.currentTimeMillis() - WEEK_IN_MILLIS);
	}
}
