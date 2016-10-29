package com.datastorm.hackreativityandroid.mvp.components;

import android.os.Build;
import android.support.annotation.NonNull;

import com.datastorm.hackreativityandroid.BuildConfig;
import com.datastorm.hackreativityandroid.utils.DateDeserializer;
import com.datastorm.hackreativityandroid.utils.PostProcessingEnabler;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import java.io.IOException;
import java.util.Date;

import okhttp3.Interceptor;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;
import okhttp3.logging.HttpLoggingInterceptor;
import retrofit2.Retrofit;
import retrofit2.adapter.rxjava.RxJavaCallAdapterFactory;
import retrofit2.converter.gson.GsonConverterFactory;


public class SquareUtils {

	public static final  String DEVICE_NAME             = Build.MODEL + " (" + Build.BRAND + ")";
	private static final String DATE_FORMAT             = "yyyy-MM-dd'T'HH:mm:ssZ";
	private static final String CONTENT_TYPE            = "Content-type";
	private static final String TEXT_JSON               = "text/json";
	private static final String ACCEPT_ENCODING         = "Accept-Encoding";
	private static final String GZIP                    = "gzip";
	private static final String USER_AGENT_HEADER_NAME  = "User-Agent";
	private static final String APPLICATION             = BuildConfig.APPLICATION_ID +
	                                                      " " + BuildConfig.VERSION_NAME +
	                                                      " (v" + BuildConfig.VERSION_CODE +
	                                                      ")";
	private static final String USER_AGENT_HEADER_VALUE = DEVICE_NAME +
	                                                      " sdk" + Build.VERSION.SDK_INT + " - " +
	                                                      APPLICATION;

	private static final String BASEURL_DEV = "http://datastorm.com/api/";

	private static OkHttpClient client;

	@NonNull
	static Retrofit retrofit() {
		Gson gson = new GsonBuilder().excludeFieldsWithoutExposeAnnotation()
		                             .setDateFormat(DATE_FORMAT)
		                             .registerTypeAdapterFactory(new PostProcessingEnabler())
		                             .registerTypeAdapter(Date.class, new DateDeserializer())
		                             .create();

		return new Retrofit.Builder().baseUrl(BASEURL_DEV)
		                             .addConverterFactory(GsonConverterFactory.create(gson))
		                             .addCallAdapterFactory(RxJavaCallAdapterFactory.create())
		                             .client(SquareUtils.okHttpClient())
		                             .build();
	}


	@NonNull
	private static OkHttpClient okHttpClient() {
		if (client == null) {
			synchronized (OkHttpClient.class) {
				if (client == null) {
					OkHttpClient.Builder clientBuilder = new OkHttpClient.Builder();

					clientBuilder.addNetworkInterceptor(new UserAgentInterceptor());

					if (BuildConfig.DEBUG) clientBuilder.addInterceptor(
							new HttpLoggingInterceptor().setLevel(
									HttpLoggingInterceptor.Level.BODY));

					client = clientBuilder.build();
				}
			}
		}
		return client;
	}

	private static class UserAgentInterceptor implements Interceptor {


		@Override
		public Response intercept(Chain chain) throws
				IOException {
			final Request originalRequest = chain.request();
			final Request requestWithUserAgent = originalRequest.newBuilder()
			                                                    .removeHeader(
					                                                    USER_AGENT_HEADER_NAME)
			                                                    .addHeader(USER_AGENT_HEADER_NAME,
					                                                    USER_AGENT_HEADER_VALUE)
			                                                    .removeHeader(CONTENT_TYPE)
			                                                    .addHeader(CONTENT_TYPE, TEXT_JSON)
			                                                    .removeHeader(ACCEPT_ENCODING)
			                                                    .addHeader(ACCEPT_ENCODING, GZIP)
			                                                    .build();
			return chain.proceed(requestWithUserAgent);
		}
	}
}
