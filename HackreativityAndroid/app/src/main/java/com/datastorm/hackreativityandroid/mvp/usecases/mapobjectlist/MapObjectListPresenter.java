package com.datastorm.hackreativityandroid.mvp.usecases.mapobjectlist;

import android.content.Context;

import com.dadino.quickstart.core.mvp.components.presenter.Presenter;
import com.datastorm.hackreativityandroid.mvp.entitites.MapObject;

import java.util.List;

import rx.Observable;

public class MapObjectListPresenter extends Presenter<List<MapObject>, MapObjectListMVP.Model>
		implements
		MapObjectListMVP.Presenter {


	public MapObjectListPresenter(Context context) {
		super(new MapObjectListModel(context.getApplicationContext()));
		setPublishLoadFinishedOnNext(true);
	}

	@Override
	protected Observable<List<MapObject>> loadItemsInternal(boolean userInitiatedLoad) {
		return model().subscribe();
	}

	@Override
	protected String tag() {
		return "MapObjectList";
	}

	@Override
	public void setTopic(String topic) {
		model().setTopic(topic);
	}
}
