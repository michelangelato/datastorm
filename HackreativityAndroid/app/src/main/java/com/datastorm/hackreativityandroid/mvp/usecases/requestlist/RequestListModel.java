package com.datastorm.hackreativityandroid.mvp.usecases.requestlist;

import android.content.Context;

import com.datastorm.hackreativityandroid.interfaces.IRequestRepository;
import com.datastorm.hackreativityandroid.mvp.entitites.Request;
import com.datastorm.hackreativityandroid.mvp.repositories.RequeryRequestRepository;

import java.util.List;

import rx.Observable;

public class RequestListModel implements RequestListMVP.Model {

	private final IRequestRepository requestRepository;

	public RequestListModel(Context context) {
		final Context applicationContext = context.getApplicationContext();
		requestRepository = new RequeryRequestRepository(applicationContext);
	}

	@Override
	public void onDestroy() {
		requestRepository.onDestroy();
	}

	@Override
	public Observable<List<Request>> subscribe() {
		return requestRepository.retrieve();
	}
}
