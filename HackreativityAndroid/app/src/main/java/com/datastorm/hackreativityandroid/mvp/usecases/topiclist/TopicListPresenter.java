package com.datastorm.hackreativityandroid.mvp.usecases.topiclist;

import android.content.Context;

import com.dadino.quickstart.core.mvp.components.presenter.Presenter;
import com.datastorm.hackreativityandroid.mvp.entitites.Topic;

import java.util.List;

import rx.Observable;

public class TopicListPresenter extends Presenter<List<Topic>, TopicListMVP.Model> implements
		TopicListMVP.Presenter {


	public TopicListPresenter(Context context) {
		super(new TopicListModel(context.getApplicationContext()));
		setPublishLoadFinishedOnNext(true);
	}

	@Override
	protected Observable<List<Topic>> loadItemsInternal(boolean userInitiatedLoad) {
		return model().subscribe();
	}

	@Override
	protected String tag() {
		return "TopicList";
	}
}
