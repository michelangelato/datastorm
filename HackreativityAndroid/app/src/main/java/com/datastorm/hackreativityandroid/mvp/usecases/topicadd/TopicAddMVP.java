package com.datastorm.hackreativityandroid.mvp.usecases.topicadd;

import android.content.Context;

import com.dadino.quickstart.core.interfaces.IModel;
import com.dadino.quickstart.core.interfaces.INext;
import com.dadino.quickstart.core.interfaces.IPresenter;
import com.dadino.quickstart.core.mvp.components.presenter.PresenterFactory;

import rx.Single;


public class TopicAddMVP {

	public interface Model extends IModel {

		Single<Boolean> add(String add);
	}

	public interface View extends INext<Boolean> {

	}

	public interface Presenter extends IPresenter<Boolean> {

		void onAddClicked(String topic);
	}

	public static class Factory implements PresenterFactory<Presenter> {

		@Override
		public TopicAddPresenter create(Context context) {
			return new TopicAddPresenter(context);
		}

		@Override
		public String tag() {
			return "TopicAddPresenter";
		}

		@Override
		public int id() {
			return 734;
		}
	}
}
