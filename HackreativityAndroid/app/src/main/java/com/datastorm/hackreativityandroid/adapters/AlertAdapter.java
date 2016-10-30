package com.datastorm.hackreativityandroid.adapters;

import android.util.Log;
import android.view.ViewGroup;

import com.dadino.quickstart.core.adapters.BaseListAdapter;
import com.datastorm.hackreativityandroid.R;
import com.datastorm.hackreativityandroid.adapters.holders.alerts.Alert1ImageHolder;
import com.datastorm.hackreativityandroid.adapters.holders.alerts.AlertBaseHolder;
import com.datastorm.hackreativityandroid.adapters.holders.alerts.AlertMapHolder;
import com.datastorm.hackreativityandroid.adapters.holders.alerts.AlertMapShortcutHolder;
import com.datastorm.hackreativityandroid.adapters.holders.alerts.AlertNImagesHolder;
import com.datastorm.hackreativityandroid.adapters.holders.alerts.AlertReportShortcutHolder;
import com.datastorm.hackreativityandroid.adapters.holders.alerts.AlertRequestShortcutHolder;
import com.datastorm.hackreativityandroid.adapters.holders.alerts.AlertTextOnlyHolder;
import com.datastorm.hackreativityandroid.interfaces.OnAlertListClickListener;
import com.datastorm.hackreativityandroid.mvp.entitites.Alert;


public class AlertAdapter extends BaseListAdapter<Alert, AlertBaseHolder> {

	private static final int POSITION_REPORT  = 0;
	private static final int POSITION_REQUEST = 1;
	private static final int POSITION_MAP     = 2;
	private OnAlertListClickListener listener;

	@Override
	public int getItemViewType(int position) {
		if (position == POSITION_REPORT) return R.layout.item_alert_report_shortcut;
		if (position == POSITION_REQUEST) return R.layout.item_alert_request_shortcut;
		if (position == POSITION_MAP) return R.layout.item_alert_map_shortcut;

		Alert alert = getItem(position);
		Log.d("UI", "Alert: " + alert.toString());

		if (alert.getMaps() != null && !alert.getMaps()
		                                     .isEmpty()) {
			Log.d("UI", "Type: map");
			return R.layout.item_alert_map;
		}
		if (alert.getImages() != null && !alert.getImages()
		                                       .isEmpty()) {

			Log.d("UI", "Type: images");
			return alert.getImages()
			            .size() == 1 ? R.layout.item_alert_1image : R.layout.item_alert_n_images;
		}

		Log.d("UI", "Type: text");
		return R.layout.item_alert_text_only;
	}

	@Override
	public long getItemIdSafe(int position) {
		return getItem(position).getId();
	}

	@Override
	public int getHeadersCount() {
		return 3;
	}

	@Override
	public void bindItem(AlertBaseHolder holder, Alert alert, int position) {
		super.bindItem(holder, alert, position);
		holder.setClickListener((v, position1, isLongClick) -> {
			if (listener == null) return;
			if (position1 == POSITION_REPORT) listener.onReportShortcutClicked(v);
			if (position1 == POSITION_REQUEST) listener.onRequestShortcutClicked(v);
			if (position1 == POSITION_MAP) listener.onMapShortcutClicked(v);
			listener.onAlertClicked(v, getItem(position1));
		});
	}

	@Override
	protected AlertBaseHolder getHolder(ViewGroup parent, int viewType) {
		Log.d("UI", "Holder: " + viewType);

		switch (viewType) {
			case R.layout.item_alert_report_shortcut:
				Log.d("UI", "Holder: shortcut report");
				return new AlertReportShortcutHolder(
						inflater(parent.getContext()).inflate(R.layout.item_alert_report_shortcut,
								parent, false));
			case R.layout.item_alert_request_shortcut:
				Log.d("UI", "Holder: shortcut request");
				return new AlertRequestShortcutHolder(
						inflater(parent.getContext()).inflate(R.layout.item_alert_request_shortcut,
								parent, false));
			case R.layout.item_alert_map_shortcut:
				Log.d("UI", "Holder: shortcut map");
				return new AlertMapShortcutHolder(
						inflater(parent.getContext()).inflate(R.layout.item_alert_map_shortcut,
								parent, false));
			case R.layout.item_alert_map:
				Log.d("UI", "Holder: map");
				return new AlertMapHolder(
						inflater(parent.getContext()).inflate(R.layout.item_alert_map, parent,
								false));
			case R.layout.item_alert_1image:
				Log.d("UI", "Holder: 1 image");
				return new Alert1ImageHolder(
						inflater(parent.getContext()).inflate(R.layout.item_alert_1image, parent,
								false));
			case R.layout.item_alert_n_images:
				Log.d("UI", "Holder: N image");
				return new AlertNImagesHolder(
						inflater(parent.getContext()).inflate(R.layout.item_alert_n_images, parent,
								false));
			case R.layout.item_alert_text_only:
				Log.d("UI", "Holder: text");
				return new AlertTextOnlyHolder(
						inflater(parent.getContext()).inflate(R.layout.item_alert_text_only,
								parent,
								false));
		}
		return null;
	}

	public void setOnAlertListClickListener(OnAlertListClickListener listener) {
		this.listener = listener;
	}
}
