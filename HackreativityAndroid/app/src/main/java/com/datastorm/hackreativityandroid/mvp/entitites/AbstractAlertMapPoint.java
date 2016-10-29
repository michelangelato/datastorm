package com.datastorm.hackreativityandroid.mvp.entitites;


import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import io.requery.Column;
import io.requery.Entity;
import io.requery.Key;
import io.requery.ManyToOne;
import io.requery.Table;

@Entity(stateless = true)
@Table(name = "alert_map_point")
public class AbstractAlertMapPoint {

	@Expose
	@SerializedName("Lat")
	@Column(name = "lat")
	@Key
	double lat;

	@Expose
	@SerializedName("Lon")
	@Column(name = "lon")
	@Key
	double lon;

	@ManyToOne
	@Column(name = "alert_map")
	@Key
	MapObject alert;
}
