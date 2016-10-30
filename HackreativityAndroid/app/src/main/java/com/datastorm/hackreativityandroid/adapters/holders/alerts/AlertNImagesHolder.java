package com.datastorm.hackreativityandroid.adapters.holders.alerts;

import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.View;

import com.datastorm.hackreativityandroid.R;
import com.datastorm.hackreativityandroid.adapters.ImageAdapter;
import com.datastorm.hackreativityandroid.mvp.entitites.Alert;

import butterknife.BindView;


public class AlertNImagesHolder extends AlertTextOnlyHolder {

	@BindView(R.id.alert_images)
	RecyclerView images;

	public AlertNImagesHolder(View itemView) {
		super(itemView);
	}

	@Override
	public void bindItem(Alert item, int position) {
		super.bindItem(item, position);
		ImageAdapter adapter = new ImageAdapter();
		adapter.setItems(item.getImages());
		images.setLayoutManager(
				new LinearLayoutManager(images.getContext(), LinearLayoutManager.HORIZONTAL,
						false));
		images.setAdapter(adapter);
	}
}

