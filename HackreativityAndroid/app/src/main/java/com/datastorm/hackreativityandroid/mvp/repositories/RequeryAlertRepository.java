package com.datastorm.hackreativityandroid.mvp.repositories;

import android.content.Context;
import android.util.Log;

import com.datastorm.hackreativityandroid.interfaces.IAlertRepository;
import com.datastorm.hackreativityandroid.mvp.entitites.Alert;
import com.datastorm.hackreativityandroid.mvp.entitites.AlertImage;
import com.datastorm.hackreativityandroid.mvp.entitites.AlertLink;
import com.datastorm.hackreativityandroid.mvp.entitites.MapObject;
import com.datastorm.hackreativityandroid.mvp.entitites.MapPoint;

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
	public Observable<List<Alert>> retrieve(String topic) {
		return db().select(Alert.class)
		           .where(Alert.TOPIC.eq(topic))
		           .get()
		           .toSelfObservable()
		           .map(Result::toList)
		           .flatMap(list -> Observable.from(list)
		                                      .flatMap(this::fillLinks)
		                                      .flatMap(this::fillMaps)
		                                      .flatMap(this::fillImages)
		                                      .toList());
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

	private Observable<Alert> fillImages(Alert alert) {
		Log.d("Repository", "Filling Images");
		return db().select(AlertImage.class)
		           .where(AlertImage.ALERT_ID.eq(alert.getId()))
		           .get()
		           .toSelfObservable()
		           .first()
		           .map(Result::toList)
		           .map(images -> {
			           alert.getImages()
			                .clear();
			           alert.getImages()
			                .addAll(images);
			           return alert;
		           });
	}

	private Observable<Alert> fillLinks(Alert alert) {
		Log.d("Repository", "Filling Links");
		return db().select(AlertLink.class)
		           .where(AlertLink.ALERT_ID.eq(alert.getId()))
		           .get()
		           .toSelfObservable()
		           .first()
		           .map(Result::toList)
		           .map(links -> {
			           alert.getLinks()
			                .clear();
			           alert.getLinks()
			                .addAll(links);
			           return alert;
		           });
	}

	private Observable<Alert> fillMaps(Alert alert) {
		Log.d("Repository", "Filling Maps");
		return db().select(MapObject.class)
		           .where(MapObject.ALERT_ID.eq(alert.getId()))
		           .get()
		           .toSelfObservable()
		           .first()
		           .map(Result::toList)
		           .flatMap(mapObjects -> Observable.from(mapObjects)
		                                            .flatMap(this::fillMapPoints)
		                                            .toList())
		           .map(mapObjects -> {
			           alert.getMaps()
			                .clear();
			           alert.getMaps()
			                .addAll(mapObjects);
			           return alert;
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
