package com.datastorm.hackreativityandroid.interfaces;


import com.dadino.quickstart.core.interfaces.IRepository;
import com.datastorm.hackreativityandroid.mvp.entitites.Alert;

import java.util.List;

import rx.Observable;
import rx.Single;

public interface IAlertRepository extends IRepository {

	Observable<List<Alert>> retrieve(String topic);
	Single<Boolean> update(List<Alert> alerts);
}
