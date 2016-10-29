package com.datastorm.hackreativityandroid.adapters.holders;

import android.view.View;

import com.datastorm.hackreativityandroid.mvp.entitites.Alert;

public class AlertRequestHolder extends AlertBaseHolder {

	public AlertRequestHolder(View itemView) {
		super(itemView, true);
	}

	@Override
	public void bindItem(Alert item, int position) {
		//TODO Richieste (clicca per richiedere un intervento)
	}
}
