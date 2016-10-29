package com.datastorm.hackreativityandroid.mvp.components;

import com.dadino.quickstart.login.mvp.http.response.BaseBody;
import com.datastorm.hackreativityandroid.mvp.entitites.Alert;

import java.util.List;

import retrofit2.Response;
import retrofit2.http.GET;
import retrofit2.http.Path;
import rx.Single;


public class WebApi {

	private static final String ALERTS = "alerts";
	private static final String ALERT  = "alerts/{id}";

	private static final String DEVICE_TOKEN = "Authorization";

	private static WebApi     api;
	private final  WebService service;

	private WebApi() {
		service = SquareUtils.retrofit()
		                     .create(WebService.class);
	}


	public static WebApi get() {
		if (api == null) {
			synchronized (WebApi.class) {
				if (api == null) {

					api = new WebApi();
				}
			}
		}
		return api;
	}

	public WebService getService() {
		return service;
	}

	public interface WebService {

		@GET(ALERTS)
		Single<Response<BaseBody<List<Alert>>>> getAlerts();
		@GET(ALERT)
		Single<Response<BaseBody<List<Alert>>>> getAlert(@Path("id") long id);

		/*
		@POST(REPORT)
		Single<Response<BaseBody<Boolean>>> postReport(@Body Report report);
		@POST(REQUEST)
		Single<Response<BaseBody<Boolean>>> postRequest(@Body Request request);
		@GET(REQUESTS)
		Single<Response<BaseBody<List<Request>>>> getRequests();
		@GET(MAP_OBJECTS)
		Single<Response<BaseBody<List<MapObject>>>> getMapObjects();
		@POST(GPS)
		Single<Response<BaseBody<GpsResponse>>> postGpsLocation(@Body GpsLocation report);
		*/
	}
}
