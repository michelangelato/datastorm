package com.datastorm.hackreativityandroid.mvp.usecases.mapobjectlist;

import android.content.Context;

import com.datastorm.hackreativityandroid.interfaces.IMapObjectRepository;
import com.datastorm.hackreativityandroid.mvp.entitites.MapObject;
import com.datastorm.hackreativityandroid.mvp.repositories.RequeryMapObjectRepository;

import java.util.List;

import rx.Observable;

public class MapObjectListModel implements MapObjectListMVP.Model {

	private final IMapObjectRepository zoneRepository;
	private       String               topic;

	public MapObjectListModel(Context context) {
		final Context applicationContext = context.getApplicationContext();
		zoneRepository = new RequeryMapObjectRepository(applicationContext);
	}

	@Override
	public void onDestroy() {
		zoneRepository.onDestroy();
	}

	@Override
	public Observable<List<MapObject>> subscribe() {
		return zoneRepository.retrieve(topic);
	}

	@Override
	public void setTopic(String topic) {
		this.topic = topic;
	}
}
