package com.datastorm.hackreativityandroid.interfaces;


import com.dadino.quickstart.core.interfaces.IRepository;
import com.datastorm.hackreativityandroid.mvp.entitites.Topic;

import java.util.List;

import rx.Single;

public interface ITopicSearchRepository extends IRepository {

	Single<List<Topic>> search(String filter);
}
