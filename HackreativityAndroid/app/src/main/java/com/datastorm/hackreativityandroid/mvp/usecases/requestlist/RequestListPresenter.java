package com.datastorm.hackreativityandroid.mvp.usecases.requestlist;

import android.content.Context;

import com.dadino.quickstart.core.mvp.components.presenter.Presenter;
import com.datastorm.hackreativityandroid.mvp.entitites.Request;

import java.util.List;

import rx.Observable;

public class RequestListPresenter extends Presenter<List<Request>, RequestListMVP.Model> implements
		RequestListMVP.Presenter {


	public RequestListPresenter(Context context) {
		super(new RequestListModel(context.getApplicationContext()));
		setPublishLoadFinishedOnNext(true);
	}

	@Override
	protected Observable<List<Request>> loadItemsInternal(boolean userInitiatedLoad) {
		return model().subscribe();
	}

	@Override
	protected String tag() {
		return "RequestList";
	}
}
