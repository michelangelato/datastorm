package com.datastorm.hackreativityandroid.adapters.holders;

import android.text.format.DateUtils;
import android.util.Log;
import android.view.View;
import android.widget.TextView;

import com.dadino.quickstart.core.adapters.holders.BaseHolder;
import com.datastorm.hackreativityandroid.R;
import com.datastorm.hackreativityandroid.mvp.entitites.Request;
import com.datastorm.hackreativityandroid.utils.Constants;

import java.util.Date;
import java.util.Locale;

import butterknife.BindView;
import butterknife.ButterKnife;

public class RequestHolder extends BaseHolder<Request> {

	@BindView(R.id.request_address)
	TextView address;
	@BindView(R.id.request_eta)
	TextView eta;
	@BindView(R.id.request_ticket_number)
	TextView number;
	@BindView(R.id.request_type)
	TextView type;

	public RequestHolder(View itemView, boolean withClickListener) {
		super(itemView, withClickListener);
		ButterKnife.bind(itemView);
	}

	@Override
	public void bindItem(Request item, int position) {
		Log.d("UI", "Binding request: " + item);
		address.setText(item.getAddress());
		eta.setText(eta(item.getEta()));
		number.setText(String.format(Locale.getDefault(), "#%d", item.getTicketNumber()));
		type.setText(Constants.typeString(type.getContext(), item.getType()));
	}

	private String eta(Date date) {
		if (date == null) return "";
		return DateUtils.getRelativeTimeSpanString(date.getTime(), System.currentTimeMillis(),
				DateUtils.MINUTE_IN_MILLIS)
		                .toString();
	}
}
