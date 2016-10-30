package com.datastorm.hackreativityandroid.mvp.usecases.topiclist;

import android.content.Context;

import com.datastorm.hackreativityandroid.interfaces.ITopicRepository;
import com.datastorm.hackreativityandroid.mvp.entitites.Topic;
import com.datastorm.hackreativityandroid.mvp.repositories.RequeryTopicRepository;

import java.util.List;

import rx.Observable;

public class TopicListModel implements TopicListMVP.Model {

	private final ITopicRepository zoneRepository;

	public TopicListModel(Context context) {
		final Context applicationContext = context.getApplicationContext();
		zoneRepository = new RequeryTopicRepository(applicationContext);
	}

	@Override
	public void onDestroy() {
		zoneRepository.onDestroy();
	}

	@Override
	public Observable<List<Topic>> subscribe() {
		return zoneRepository.retrieve();
	}
}
