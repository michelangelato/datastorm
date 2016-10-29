package com.datastorm.hackreativityandroid.mvp.repositories;

import android.content.Context;

import com.datastorm.hackreativityandroid.interfaces.ITopicRepository;
import com.datastorm.hackreativityandroid.mvp.entitites.Topic;

import java.util.Date;
import java.util.List;

import io.requery.query.Result;
import rx.Observable;
import rx.Single;

//TODO switch to retrofit
public class RetrofitTopicRepository extends RequeryRepository implements ITopicRepository {

	public RetrofitTopicRepository(Context context) {
		super(context);
	}

	@Override
	public Observable<List<Topic>> retrieve() {
		return db().select(Topic.class)
		           .get()
		           .toSelfObservable()
		           .map(Result::toList);
	}

	@Override
	public Observable<List<Topic>> search(String filter) {
		return db().select(Topic.class)
		           .where(Topic.TOPIC.like(filter))
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
				db().upsert(topic);
				singleSubscriber.onSuccess(true);
			} catch (Exception e) {
				singleSubscriber.onError(e);
			}
		});
	}
}
