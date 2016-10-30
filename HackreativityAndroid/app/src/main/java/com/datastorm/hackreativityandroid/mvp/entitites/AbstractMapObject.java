package com.datastorm.hackreativityandroid.mvp.entitites;


import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import java.util.List;

import io.requery.CascadeAction;
import io.requery.Column;
import io.requery.Entity;
import io.requery.Key;
import io.requery.ManyToOne;
import io.requery.OneToMany;
import io.requery.Table;

@Entity(stateless = true)
@Table(name = "map_object")
public class AbstractMapObject {

	@Expose
	@SerializedName("Id")
	@Column(name = "id")
	@Key
	long id;

	@Expose
	@SerializedName("Topic")
	@Column(name = "topic")
	String topic;

	@Expose
	@SerializedName("Tipo")
	@Column(name = "type")
	int type;

	@Expose
	@SerializedName("Titolo")
	@Column(name = "title")
	String title;

	@Expose
	@SerializedName("Descrizione")
	@Column(name = "description")
	String description;

	@ManyToOne
	@Column(name = "alert")
	Alert alert;

	@Expose
	@SerializedName("Punti")
	@Column(name = "points")
	@OneToMany(cascade = {CascadeAction.DELETE, CascadeAction.SAVE})
	List<MapPoint> points;
}
