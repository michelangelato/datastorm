package com.datastorm.hackreativityandroid;

import com.dadino.quickstart.core.App;
import com.dadino.quickstart.login.QuickStartLogin;
import com.datastorm.hackreativityandroid.mvp.repositories.RetrofitLoginRepository;
import com.datastorm.hackreativityandroid.utils.DbBackupHelper;


public class HackApp extends App {

	@Override
	public void onCreate() {
		super.onCreate();
		QuickStartLogin.setLoginRepository(new RetrofitLoginRepository());
		DbBackupHelper.backupDatabase(this);
	}
}
