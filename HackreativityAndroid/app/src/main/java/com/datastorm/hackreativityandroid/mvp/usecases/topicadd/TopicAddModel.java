package com.datastorm.hackreativityandroid.mvp.usecases.topicadd;

import android.content.Context;

import com.datastorm.hackreativityandroid.interfaces.ITopicRepository;
import com.datastorm.hackreativityandroid.mvp.repositories.RequeryTopicRepository;

import rx.Single;

public class TopicAddModel implements TopicAddMVP.Model {

	private final ITopicRepository topicRepository;

	public TopicAddModel(Context context) {
		final Context applicationContext = context.getApplicationContext();
		topicRepository = new RequeryTopicRepository(applicationContext);
	}

	@Override
	public void onDestroy() {
		topicRepository.onDestroy();
	}

	@Override
	public Single<Boolean> add(String topic) {
		return topicRepository.upsert(topic);
	}
}
