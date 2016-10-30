package com.datastorm.hackreativityandroid.mvp.usecases.alertlist;

import android.content.Context;

import com.datastorm.hackreativityandroid.interfaces.IAlertRepository;
import com.datastorm.hackreativityandroid.mvp.entitites.Alert;
import com.datastorm.hackreativityandroid.mvp.repositories.RequeryAlertRepository;

import java.util.List;

import rx.Observable;

public class AlertListModel implements AlertListMVP.Model {

	private final IAlertRepository zoneRepository;
	private       String           topic;

	public AlertListModel(Context context) {
		final Context applicationContext = context.getApplicationContext();
		zoneRepository = new RequeryAlertRepository(applicationContext);
	}

	@Override
	public void onDestroy() {
		zoneRepository.onDestroy();
	}

	@Override
	public Observable<List<Alert>> subscribe() {
		return zoneRepository.retrieve(topic);
	}

	@Override
	public void setTopic(String topic) {
		this.topic = topic;
	}
}
