package com.datastorm.hackreativityandroid.mvp.repositories;

import android.content.Context;

import com.dadino.quickstart.login.mvp.http.response.BaseBody;
import com.datastorm.hackreativityandroid.interfaces.ITopicSearchRepository;
import com.datastorm.hackreativityandroid.mvp.components.WebApi;
import com.datastorm.hackreativityandroid.mvp.entitites.Topic;

import java.util.List;

import rx.Single;
import rx.schedulers.Schedulers;

public class RetrofitTopicRepository extends RequeryRepository implements ITopicSearchRepository {

	private final WebApi.WebService api;

	public RetrofitTopicRepository(Context context) {
		super(context);
		api = WebApi.get()
		            .getService();
	}

	@Override
	public Single<List<Topic>> search(String filter) {
		return api.getTopics(filter)
		          .map(BaseBody::data)
		          .subscribeOn(Schedulers.io());
	}
}
