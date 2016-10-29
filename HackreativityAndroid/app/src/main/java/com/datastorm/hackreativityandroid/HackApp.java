package com.datastorm.hackreativityandroid;

import com.dadino.quickstart.core.App;
import com.dadino.quickstart.login.QuickStartLogin;
import com.datastorm.hackreativityandroid.mvp.repositories.RetrofitLoginRepository;


public class HackApp extends App {

	@Override
	public void onCreate() {
		super.onCreate();
		QuickStartLogin.setLoginRepository(new RetrofitLoginRepository());
	}
}
