package com.datastorm.hackreativityandroid.mvp.repositories;

import android.content.Context;

import com.datastorm.hackreativityandroid.interfaces.IRequestRepository;
import com.datastorm.hackreativityandroid.mvp.entitites.Request;

import java.util.List;

import io.requery.Transaction;
import io.requery.query.Result;
import rx.Observable;
import rx.Single;

public class RequeryRequestRepository extends RequeryRepository implements IRequestRepository {

	public RequeryRequestRepository(Context context) {
		super(context);
	}

	@Override
	public Observable<List<Request>> retrieve() {
		return db().select(Request.class)
		           .orderBy(Request.TICKET_NUMBER)
		           .get()
		           .toSelfObservable()
		           .map(Result::toList);
	}

	@Override
	public Single<Boolean> update(List<Request> requests) {
		return Single.create(singleSubscriber -> {
			Transaction trans = db().transaction();
			try {
				trans.begin();
				db().delete(Request.class)
				    .get()
				    .value();
				db().insert(requests);
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

	@Override
	public Single<Boolean> insert(Request request) {
		return Single.create(singleSubscriber -> {
			try {
				db().insert(request);
				singleSubscriber.onSuccess(true);
			} catch (Exception e) {
				singleSubscriber.onError(e);
			}
		});
	}
}
