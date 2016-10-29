package com.datastorm.hackreativityandroid.adapters.holders;

import android.view.View;
import android.widget.ImageView;

import com.dadino.quickstart.core.adapters.holders.BaseHolder;
import com.datastorm.hackreativityandroid.R;
import com.datastorm.hackreativityandroid.mvp.entitites.AlertImage;
import com.squareup.picasso.Picasso;

import butterknife.BindView;

public class ImageHolder extends BaseHolder<AlertImage> {

	@BindView(R.id.alert_image)
	ImageView image;

	public ImageHolder(View itemView) {
		super(itemView);
	}

	public static int layout() {
		return R.layout.item_alert_image;
	}

	@Override
	public void bindItem(AlertImage item, int position) {
		Picasso.with(image.getContext())
		       .load(item.getUrl())
		       .into(image);
	}
}
