package com.datastorm.hackreativityandroid.mvp.usecases.topicsearch;

import android.content.Context;

import com.datastorm.hackreativityandroid.interfaces.ITopicRepository;
import com.datastorm.hackreativityandroid.mvp.entitites.Topic;
import com.datastorm.hackreativityandroid.mvp.repositories.RetrofitTopicRepository;

import java.util.List;

import rx.Observable;

public class TopicSearchListModel implements TopicSearchListMVP.Model {

	private final ITopicRepository topicRepository;

	public TopicSearchListModel(Context context) {
		final Context applicationContext = context.getApplicationContext();
		topicRepository = new RetrofitTopicRepository(applicationContext);
	}

	@Override
	public void onDestroy() {
		topicRepository.onDestroy();
	}

	@Override
	public Observable<List<Topic>> search(String filter) {
		return topicRepository.search(filter);
	}
}
