package com.datastorm.hackreativityandroid.mvp.entitites;


import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import io.requery.Column;
import io.requery.Entity;
import io.requery.Key;
import io.requery.ManyToOne;
import io.requery.Table;

@Entity(stateless = true)
@Table(name = "map_point")
public class AbstractMapPoint {

	@Expose
	@SerializedName("Id")
	@Column(name = "id")
	@Key
	long id;

	@Expose
	@SerializedName("Lat")
	@Column(name = "lat")
	double lat;

	@Expose
	@SerializedName("Lon")
	@Column(name = "lon")
	double lon;

	@ManyToOne
	@Column(name = "map_object")
	MapObject mapObject;
}
