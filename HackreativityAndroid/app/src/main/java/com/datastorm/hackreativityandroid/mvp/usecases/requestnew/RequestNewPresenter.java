package com.datastorm.hackreativityandroid.mvp.usecases.requestnew;

import android.content.Context;

import com.dadino.quickstart.core.mvp.components.presenter.Presenter;
import com.datastorm.hackreativityandroid.mvp.entitites.Request;

import rx.Observable;

public class RequestNewPresenter extends Presenter<Boolean, RequestNewMVP.Model> implements
		RequestNewMVP.Presenter {


	public RequestNewPresenter(Context context) {
		super(new RequestNewModel(context.getApplicationContext()));
		setPublishLoadFinishedOnNext(true);
	}

	@Override
	protected Observable<Boolean> loadItemsInternal(boolean userInitiatedLoad) {
		throw new RuntimeException("Method not implemented");
	}

	@Override
	protected String tag() {
		return "RequestNew";
	}

	@Override
	public void onSendClicked(Request request) {
		model().add(request);
	}
}
