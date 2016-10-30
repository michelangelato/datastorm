package com.datastorm.hackreativityandroid.mvp.usecases.requestnew;

import android.content.Context;

import com.datastorm.hackreativityandroid.interfaces.IRequestRepository;
import com.datastorm.hackreativityandroid.mvp.entitites.Request;
import com.datastorm.hackreativityandroid.mvp.repositories.RequeryRequestRepository;

import rx.Single;

public class RequestNewModel implements RequestNewMVP.Model {

	private final IRequestRepository topicRepository;

	public RequestNewModel(Context context) {
		final Context applicationContext = context.getApplicationContext();
		topicRepository = new RequeryRequestRepository(applicationContext);
	}

	@Override
	public void onDestroy() {
		topicRepository.onDestroy();
	}

	@Override
	public Single<Boolean> add(Request request) {
		return topicRepository.insert(request);
	}
}
