package com.datastorm.hackreativityandroid.mvp.repositories;

import com.dadino.quickstart.login.interfaces.IWebApiRepository;
import com.dadino.quickstart.login.mvp.http.request.Credentials;
import com.dadino.quickstart.login.mvp.http.response.BaseBody;
import com.datastorm.hackreativityandroid.mvp.components.WebApi;

import retrofit2.Response;
import rx.Single;

public class RetrofitLoginRepository implements IWebApiRepository {

	private final WebApi.WebService api;

	public RetrofitLoginRepository() {
		api = WebApi.get()
		            .getService();
	}

	@Override
	public Single<Response<BaseBody<String>>> login(Credentials credentials) {
		//TODO
		return null;
	}

	@Override
	public Single<Response<BaseBody<String>>> register(Credentials credentials) {
		//TODO
		return null;
	}
}
