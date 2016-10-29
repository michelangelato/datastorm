package com.datastorm.hackreativityandroid.mvp.usecases.alertlist;

import android.content.Context;

import com.dadino.quickstart.core.interfaces.IModel;
import com.dadino.quickstart.core.interfaces.INext;
import com.dadino.quickstart.core.interfaces.IPresenter;
import com.dadino.quickstart.core.mvp.components.presenter.PresenterFactory;
import com.datastorm.hackreativityandroid.mvp.entitites.Alert;

import java.util.List;

import rx.Observable;


public class AlertListMVP {

	public interface Model extends IModel {

		Observable<List<Alert>> subscribe();
	}

	public interface View extends INext<List<Alert>> {

	}

	public interface Presenter extends IPresenter<List<Alert>> {

	}

	public static class Factory implements PresenterFactory<Presenter> {

		@Override
		public AlertListPresenter create(Context context) {
			return new AlertListPresenter(context);
		}

		@Override
		public String tag() {
			return "SubscriptionListPresenter";
		}

		@Override
		public int id() {
			return 654;
		}
	}
}
