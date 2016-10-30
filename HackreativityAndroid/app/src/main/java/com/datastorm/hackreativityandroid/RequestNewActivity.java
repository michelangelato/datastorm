package com.datastorm.hackreativityandroid;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;

import com.dadino.quickstart.core.BaseActivity;
import com.datastorm.hackreativityandroid.fragments.RequestNewFragment;
import com.datastorm.hackreativityandroid.interfaces.OnRequestNewInteractionListener;

public class RequestNewActivity extends BaseActivity implements OnRequestNewInteractionListener {

	public static void show(Context context) {
		context.startActivity(new Intent(context, RequestNewActivity.class));
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_request_new);
		getSupportFragmentManager().beginTransaction()
		                           .replace(R.id.fragment_container,
				                           RequestNewFragment.newInstance())
		                           .commitNow();
	}
}
