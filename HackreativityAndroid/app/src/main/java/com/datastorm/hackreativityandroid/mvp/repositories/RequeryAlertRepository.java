package com.datastorm.hackreativityandroid.mvp.repositories;

import android.content.Context;
import android.text.TextUtils;

import com.datastorm.hackreativityandroid.interfaces.IAlertRepository;
import com.datastorm.hackreativityandroid.mvp.entitites.Alert;

import java.util.List;

import io.requery.Transaction;
import io.requery.query.Result;
import io.requery.query.Selection;
import rx.Observable;
import rx.Single;

public class RequeryAlertRepository extends RequeryRepository implements IAlertRepository {

	public RequeryAlertRepository(Context context) {
		super(context);
	}

	@Override
	public Observable<List<Alert>> retrieve(String topic) {
		final Selection<Result<Alert>> select = db().select(Alert.class);
		if (!TextUtils.isEmpty(topic)) return select.where(Alert.TOPIC.eq(topic))
		                                            .get()
		                                            .toSelfObservable()
		                                            .map(Result::toList);
		return select.get()
		             .toSelfObservable()
		             .map(Result::toList);
	}

	@Override
	public Single<Boolean> update(List<Alert> alerts) {
		return Single.create(singleSubscriber -> {
			Transaction trans = db().transaction();
			try {
				trans.begin();
				db().delete(Alert.class)
				    .get()
				    .value();
				db().insert(alerts);
				trans.commit();
				singleSubscriber.onSuccess(true);
			} catch (Exception e) {
				trans.rollback();
				singleSubscriber.onError(e);
			} finally {
				trans.close();
			}
		});
	}
}
