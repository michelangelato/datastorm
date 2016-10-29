package com.datastorm.hackreativityandroid.adapters;

import android.view.ViewGroup;

import com.dadino.quickstart.core.adapters.BaseListAdapter;
import com.datastorm.hackreativityandroid.R;
import com.datastorm.hackreativityandroid.adapters.holders.alerts.AlertBaseHolder;
import com.datastorm.hackreativityandroid.mvp.entitites.Alert;


public class AlertAdapter extends BaseListAdapter<Alert, AlertBaseHolder> {

	@Override
	public int getItemViewType(int position) {
		if (position == 0) return R.layout.item_alert_report_shortcut;
		if (position == 1) return R.layout.item_alert_request_shortcut;
		if (position == 2) return R.layout.item_alert_map_shortcut;

		Alert alert = getItem(position);
		if (alert.getMaps() != null && !alert.getMaps()
		                                     .isEmpty()) return R.layout.item_alert_map;
		if (alert.getImages() != null && !alert.getImages()
		                                       .isEmpty()) return alert.getImages()
		                                                               .size() == 1 ?
		                                                          R.layout.item_alert_1image :
		                                                          R.layout.item_alert_n_images;
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
	protected AlertBaseHolder getHolder(ViewGroup parent, int viewType) {
		return null;
	}
}
