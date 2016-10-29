package com.datastorm.hackreativityandroid.mvp.usecases.requestlist;

import android.content.Context;

import com.datastorm.hackreativityandroid.interfaces.IRequestRepository;
import com.datastorm.hackreativityandroid.mvp.entitites.Request;
import com.datastorm.hackreativityandroid.mvp.repositories.RequeryRequestRepository;

import java.util.List;

import rx.Observable;

public class RequestListModel implements RequestListMVP.Model {

	private final IRequestRepository zoneRepository;

	public RequestListModel(Context context) {
		final Context applicationContext = context.getApplicationContext();
		zoneRepository = new RequeryRequestRepository(applicationContext);
	}

	@Override
	public void onDestroy() {
		zoneRepository.onDestroy();
	}

	@Override
	public Observable<List<Request>> subscribe() {
		return zoneRepository.retrieve();
	}
}
