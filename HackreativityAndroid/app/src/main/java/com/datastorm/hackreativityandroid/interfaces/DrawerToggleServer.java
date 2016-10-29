package com.datastorm.hackreativityandroid.interfaces;

import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;

public interface DrawerToggleServer {

	DrawerLayout getDrawer();
	void setDrawerToggle(ActionBarDrawerToggle toggle);
	void removeDrawerToggle();
}
