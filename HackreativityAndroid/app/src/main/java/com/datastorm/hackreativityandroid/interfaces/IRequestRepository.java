package com.datastorm.hackreativityandroid.interfaces;


import com.dadino.quickstart.core.interfaces.IRepository;
import com.datastorm.hackreativityandroid.mvp.entitites.Request;

import java.util.List;

import rx.Observable;
import rx.Single;

public interface IRequestRepository extends IRepository {

	Observable<List<Request>> retrieve();
	Single<Boolean> update(List<Request> requests);
}
