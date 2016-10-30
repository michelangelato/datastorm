package com.datastorm.hackreativityandroid.mvp.usecases.requestnew;

import android.content.Context;

import com.dadino.quickstart.core.interfaces.IModel;
import com.dadino.quickstart.core.interfaces.INext;
import com.dadino.quickstart.core.interfaces.IPresenter;
import com.dadino.quickstart.core.mvp.components.presenter.PresenterFactory;
import com.datastorm.hackreativityandroid.mvp.entitites.Request;

import rx.Single;


public class RequestNewMVP {

	public interface Model extends IModel {

		Single<Boolean> add(Request request);
	}

	public interface View extends INext<Boolean> {

	}

	public interface Presenter extends IPresenter<Boolean> {

		void onSendClicked(Request request);
	}

	public static class Factory implements PresenterFactory<Presenter> {

		@Override
		public RequestNewPresenter create(Context context) {
			return new RequestNewPresenter(context);
		}

		@Override
		public String tag() {
			return "RequestNewPresenter";
		}

		@Override
		public int id() {
			return 734;
		}
	}
}
