package com.datastorm.hackreativityandroid.mvp.repositories;

import android.content.Context;
import android.text.TextUtils;

import com.datastorm.hackreativityandroid.interfaces.IMapObjectRepository;
import com.datastorm.hackreativityandroid.mvp.entitites.MapObject;

import java.util.List;

import io.requery.Transaction;
import io.requery.query.Result;
import io.requery.query.Selection;
import rx.Observable;
import rx.Single;

public class RequeryMapObjectRepository extends RequeryRepository implements IMapObjectRepository {

	public RequeryMapObjectRepository(Context context) {
		super(context);
	}

	@Override
	public Observable<List<MapObject>> retrieve(String topic) {
		final Selection<Result<MapObject>> select = db().select(MapObject.class);
		if (!TextUtils.isEmpty(topic)) return select.where(MapObject.TOPIC.eq(topic))
		                                            .get()
		                                            .toSelfObservable()
		                                            .map(Result::toList);
		return select.get()
		             .toSelfObservable()
		             .map(Result::toList);
	}

	@Override
	public Single<Boolean> update(List<MapObject> mapObjects) {
		return Single.create(singleSubscriber -> {
			Transaction trans = db().transaction();
			try {
				trans.begin();
				db().delete(MapObject.class)
				    .get()
				    .value();
				db().insert(mapObjects);
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
