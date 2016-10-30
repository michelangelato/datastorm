package com.datastorm.hackreativityandroid.mvp.usecases.mapobjectlist;

import android.content.Context;

import com.dadino.quickstart.core.interfaces.IModel;
import com.dadino.quickstart.core.interfaces.INext;
import com.dadino.quickstart.core.interfaces.IPresenter;
import com.dadino.quickstart.core.mvp.components.presenter.PresenterFactory;
import com.datastorm.hackreativityandroid.mvp.entitites.MapObject;

import java.util.List;

import rx.Observable;


public class MapObjectListMVP {

	public interface Model extends IModel {

		Observable<List<MapObject>> subscribe();
		void setTopic(String topic);
	}

	public interface View extends INext<List<MapObject>> {

	}

	public interface Presenter extends IPresenter<List<MapObject>> {

		void setTopic(String topic);
	}

	public static class Factory implements PresenterFactory<Presenter> {

		@Override
		public MapObjectListPresenter create(Context context) {
			return new MapObjectListPresenter(context);
		}

		@Override
		public String tag() {
			return "MapObjectListPresenter";
		}

		@Override
		public int id() {
			return 4;
		}
	}
}
