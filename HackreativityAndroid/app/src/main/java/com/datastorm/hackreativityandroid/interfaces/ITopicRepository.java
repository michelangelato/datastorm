package com.datastorm.hackreativityandroid.interfaces;


import com.dadino.quickstart.core.interfaces.IRepository;
import com.datastorm.hackreativityandroid.mvp.entitites.Topic;

import java.util.List;

import rx.Observable;
import rx.Single;

public interface ITopicRepository extends IRepository {

	Observable<List<Topic>> retrieve();
	Observable<List<Topic>> search(String filter);
	Single<Boolean> upsert(Topic topic);
	Single<Boolean> upsert(String topicName);
}
