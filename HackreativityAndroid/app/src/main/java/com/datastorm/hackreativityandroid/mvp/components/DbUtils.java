package com.datastorm.hackreativityandroid.mvp.components;

import android.content.Context;

import com.datastorm.hackreativityandroid.mvp.entitites.Models;

import io.requery.Persistable;
import io.requery.android.sqlite.DatabaseSource;
import io.requery.meta.EntityModel;
import io.requery.sql.Configuration;
import io.requery.sql.ConfigurationBuilder;
import io.requery.sql.EntityDataStore;

public class DbUtils {

	private final static int DB_VERSION = 1;

	private static EntityDataStore<Persistable> dataStore;

	public static EntityDataStore<Persistable> getDB(Context context) {
		if (dataStore == null) {
			synchronized (EntityDataStore.class) {
				if (dataStore == null) {
					EntityModel model = Models.DEFAULT;
					DatabaseSource dataSource = new DatabaseSource(context, model, DB_VERSION);
					Configuration configuration = new ConfigurationBuilder(dataSource,
							model).useDefaultLogging()
					              .build();
					dataStore = new EntityDataStore<>(configuration);
				}
			}
		}
		return dataStore;
	}

}
