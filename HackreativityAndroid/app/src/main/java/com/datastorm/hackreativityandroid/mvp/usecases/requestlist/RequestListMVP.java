package com.datastorm.hackreativityandroid.mvp.usecases.requestlist;

import android.content.Context;

import com.dadino.quickstart.core.interfaces.IModel;
import com.dadino.quickstart.core.interfaces.INext;
import com.dadino.quickstart.core.interfaces.IPresenter;
import com.dadino.quickstart.core.mvp.components.presenter.PresenterFactory;
import com.datastorm.hackreativityandroid.mvp.entitites.Request;

import java.util.List;

import rx.Observable;


public class RequestListMVP {

	public interface Model extends IModel {

		Observable<List<Request>> subscribe();
	}

	public interface View extends INext<List<Request>> {

	}

	public interface Presenter extends IPresenter<List<Request>> {

	}

	public static class Factory implements PresenterFactory<Presenter> {

		@Override
		public RequestListPresenter create(Context context) {
			return new RequestListPresenter(context);
		}

		@Override
		public String tag() {
			return "RequestListPresenter";
		}

		@Override
		public int id() {
			return 654;
		}
	}
}
