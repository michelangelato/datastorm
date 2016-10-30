package com.datastorm.hackreativityandroid.mvp.repositories;

import android.content.Context;
import android.util.Log;

import com.datastorm.hackreativityandroid.interfaces.IMapObjectRepository;
import com.datastorm.hackreativityandroid.mvp.entitites.MapObject;
import com.datastorm.hackreativityandroid.mvp.entitites.MapPoint;

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

		return select.get()
		             .toSelfObservable()
		             .map(Result::toList)
		             .flatMap(list -> Observable.from(list)
		                                        .flatMap(this::fillMapPoints)
		                                        .toList());
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


	private Observable<MapObject> fillMapPoints(MapObject mapObject) {
		Log.d("Repository", "Filling MapPoints");
		return db().select(MapPoint.class)
		           .where(MapPoint.MAP_OBJECT_ID.eq(mapObject.getId()))
		           .get()
		           .toSelfObservable()
		           .first()
		           .map(Result::toList)
		           .map(points -> {
			           mapObject.getPoints()
			                    .clear();
			           mapObject.getPoints()
			                    .addAll(points);
			           return mapObject;
		           });
	}
}
