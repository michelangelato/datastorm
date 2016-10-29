package com.datastorm.hackreativityandroid.mvp.repositories;

import android.content.Context;

import com.datastorm.hackreativityandroid.interfaces.IAlertRepository;
import com.datastorm.hackreativityandroid.mvp.entitites.Alert;

import java.util.List;

import io.requery.Transaction;
import io.requery.query.Result;
import rx.Observable;
import rx.Single;

public class RequeryAlertRepository extends RequeryRepository implements IAlertRepository {

	public RequeryAlertRepository(Context context) {
		super(context);
	}

	@Override
	public Observable<List<Alert>> retrieve() {
		return db().select(Alert.class)
		           .get()
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
