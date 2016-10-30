package com.datastorm.hackreativityandroid.mvp.usecases.topiclist;

import android.content.Context;

import com.dadino.quickstart.core.interfaces.IModel;
import com.dadino.quickstart.core.interfaces.INext;
import com.dadino.quickstart.core.interfaces.IPresenter;
import com.dadino.quickstart.core.mvp.components.presenter.PresenterFactory;
import com.datastorm.hackreativityandroid.mvp.entitites.Topic;

import java.util.List;

import rx.Observable;


public class TopicListMVP {

	public interface Model extends IModel {

		Observable<List<Topic>> subscribe();
	}

	public interface View extends INext<List<Topic>> {

	}

	public interface Presenter extends IPresenter<List<Topic>> {

	}

	public static class Factory implements PresenterFactory<Presenter> {

		@Override
		public TopicListPresenter create(Context context) {
			return new TopicListPresenter(context);
		}

		@Override
		public String tag() {
			return "TopicListPresenter";
		}

		@Override
		public int id() {
			return 75;
		}
	}
}
