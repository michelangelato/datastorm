package com.datastorm.hackreativityandroid.mvp.usecases.alertlist;

import android.content.Context;

import com.dadino.quickstart.core.mvp.components.presenter.Presenter;
import com.datastorm.hackreativityandroid.mvp.entitites.Alert;

import java.util.List;

import rx.Observable;

public class AlertListPresenter extends Presenter<List<Alert>, AlertListMVP.Model> implements
		AlertListMVP.Presenter {


	public AlertListPresenter(Context context) {
		super(new AlertListModel(context.getApplicationContext()));
		setPublishLoadFinishedOnNext(true);
	}

	@Override
	protected Observable<List<Alert>> loadItemsInternal(boolean userInitiatedLoad) {
		return model().subscribe();
	}

	@Override
	protected String tag() {
		return "AlertList";
	}
}
