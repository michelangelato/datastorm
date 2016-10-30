package com.datastorm.hackreativityandroid.mvp.repositories;

import android.content.Context;

import com.dadino.quickstart.core.interfaces.IRepository;
import com.datastorm.hackreativityandroid.mvp.components.DbUtils;

import io.requery.Persistable;
import io.requery.sql.EntityDataStore;

public class RequeryRepository implements IRepository {

	private final EntityDataStore<Persistable> db;

	public RequeryRepository(Context context) {
		db = DbUtils.getDB(context);
	}

	@Override
	public void onDestroy() {

	}

	protected EntityDataStore<Persistable> db() {
		return db;
	}
}
