package com.datastorm.hackreativityandroid.mvp.usecases.topicsearch;

import android.content.Context;

import com.dadino.quickstart.core.interfaces.IModel;
import com.dadino.quickstart.core.interfaces.INext;
import com.dadino.quickstart.core.interfaces.IPresenter;
import com.dadino.quickstart.core.mvp.components.presenter.PresenterFactory;
import com.datastorm.hackreativityandroid.mvp.entitites.Topic;

import java.util.List;

import rx.Single;


public class TopicSearchListMVP {

	public interface Model extends IModel {

		Single<List<Topic>> search(String filter);
	}

	public interface View extends INext<List<Topic>> {

	}

	public interface Presenter extends IPresenter<List<Topic>> {

		void onFilterChanged(String filter);
	}

	public static class Factory implements PresenterFactory<Presenter> {

		@Override
		public TopicSearchListPresenter create(Context context) {
			return new TopicSearchListPresenter(context);
		}

		@Override
		public String tag() {
			return "TopicSearchListPresenter";
		}

		@Override
		public int id() {
			return 75;
		}
	}
}
