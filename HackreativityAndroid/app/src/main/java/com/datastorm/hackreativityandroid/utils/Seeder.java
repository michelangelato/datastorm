package com.datastorm.hackreativityandroid.utils;


import android.content.Context;

import com.datastorm.hackreativityandroid.interfaces.IAlertRepository;
import com.datastorm.hackreativityandroid.interfaces.IMapObjectRepository;
import com.datastorm.hackreativityandroid.interfaces.IRequestRepository;
import com.datastorm.hackreativityandroid.interfaces.ITopicRepository;
import com.datastorm.hackreativityandroid.mvp.entitites.Alert;
import com.datastorm.hackreativityandroid.mvp.entitites.AlertImage;
import com.datastorm.hackreativityandroid.mvp.entitites.MapObject;
import com.datastorm.hackreativityandroid.mvp.entitites.MapPoint;
import com.datastorm.hackreativityandroid.mvp.entitites.Request;
import com.datastorm.hackreativityandroid.mvp.repositories.RequeryAlertRepository;
import com.datastorm.hackreativityandroid.mvp.repositories.RequeryMapObjectRepository;
import com.datastorm.hackreativityandroid.mvp.repositories.RequeryRequestRepository;
import com.datastorm.hackreativityandroid.mvp.repositories.RequeryTopicRepository;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Random;

import rx.Observable;
import rx.Single;

public class Seeder {

	private static final String photo1 = "https://s.yimg.com/bt/api/res/1" +
	                                     ".2/a2kIoVXV5Nmy0AFmtKkqAw" +
	                                     "--/YXBwaWQ9eW5ld3NfbGVnbztmaT1pbnNldDtoPTM0MTtpbD1wbGFuZTtxPTc1O3c9NTEy" +
	                                     "/http" +
	                                     "://media.zenfs" +
	                                     ".com/en_sg/News/AFP/8fe71d3ec7054e0ad3e9ba31414e249f96888645" +
	                                     ".jpg";
	private static final String photo2 =
			"http://www.riscossacristiana.it/newwebsite/wp-content/uploads/2016/10/zCamerino1.jpg";

	private static final String photo3 = "http://cdn.cronachemaceratesi" +
	                                     ".it/wp-content/uploads/2016/10/camerino-andrea-petinari" +
	                                     "-terremoto-26-ottobre-12-650x433.jpeg";

	public static void seed(Context context) {
		//TODO add stuff to the db
		Observable.concat(seedAlerts(context), seedTopics(context), seedMapObjects(context),
				seedRequests(context))
		          .subscribe();
	}


	private static Observable<Boolean> seedTopics(Context context) {
		ITopicRepository repository = new RequeryTopicRepository(context);
		return Single.concat(repository.upsert("camerino"), repository.upsert("fabriano"),
				repository.upsert("norcia"));
	}

	private static Observable<Boolean> seedRequests(Context context) {
		IRequestRepository repository = new RequeryRequestRepository(context);
		List<Request> requests = new ArrayList<>();

		Request request = new Request();
		request.setAddress("Via della Vittoria, 15, Fabriano");
		request.setConditionDoor(true);
		request.setConditionStairs(false);
		request.setEta(new Date(System.currentTimeMillis() + 1000 * 60 * 60 * 4));
		request.setTicketNumber(141);
		request.setRequestedAt(new Date());
		request.setType(0);
		requests.add(request);

		Request request2 = new Request();
		request2.setAddress("Via della Pace, 16, Camerino");
		request2.setType(0);
		request2.setConditionDoor(false);
		request2.setConditionStairs(true);
		request2.setEta(new Date(System.currentTimeMillis() + 1000 * 60 * 60 * 12));
		request2.setTicketNumber(345);
		request2.setRequestedAt(new Date());
		requests.add(request2);

		return repository.update(requests)
		                 .toObservable();
	}

	private static Observable<Boolean> seedAlerts(Context context) {
		List<Alert> alerts = new ArrayList<>();
		for (int i = 0; i < 100; i++) {
			alerts.add(createAlert(i));
		}
		IAlertRepository repository = new RequeryAlertRepository(context);
		return repository.update(alerts)
		                 .toObservable();
	}

	private static Alert createAlert(long id) {
		Alert alert = new Alert();
		alert.setId(id);
		alert.setTitle("Avviso " + id);
		alert.setDescription("Messaggi di servizio " + id);
		alert.setTopic(random(new String[]{"camerino", "fabriano", "norcia"}));
		alert.getImages();
		createImages(alert);
		createMapObjects(alert);
		return alert;
	}

	private static void createImages(Alert alert) {
		for (int i = 0; i < random(0, 1); i++) {
			alert.getImages()
			     .add(createImage(alert, alert.getId() * 1000 + i));
		}
	}

	private static AlertImage createImage(Alert alert, long id) {
		AlertImage image = new AlertImage();
		image.setId(id);
		image.setAlert(alert);
		random(image);
		return image;
	}


	private static void createMapObjects(Alert alert) {
		for (int i = 0; i < random(0, 3); i++) {
			alert.getMaps()
			     .add(createMapObject(alert, alert.getId() * 1000 + i));
		}
	}

	private static MapObject createMapObject(Alert alert, long id) {
		MapObject mapObject = new MapObject();
		mapObject.setId(id);
		mapObject.setTitle("Punto d'interesse " + id);
		mapObject.setDescription("Descrizione " + id);
		mapObject.setTopic(random(new String[]{"camerino", "fabriano", "norcia"}));
		mapObject.setType(random(1, 3));
		mapObject.setAlert(alert);
		createMapPoints(mapObject);
		return mapObject;
	}

	private static void createMapPoints(MapObject mapObject) {
		for (int i = 0; i < random(mapObject.getType(), mapObject.getType() + 3); i++) {
			mapObject.getPoints()
			         .add(createMapPoint(mapObject, mapObject.getId() * 1000 + i));
		}
	}

	private static MapPoint createMapPoint(MapObject alert, long id) {
		MapPoint mapPoint = new MapPoint();
		mapPoint.setId(id);
		mapPoint.setMapObject(alert);
		mapPoint.setLat(random(43.0, 43.5));
		mapPoint.setLon(random(13.0, 13.5));
		return mapPoint;
	}

	private static String random(String[] strings) {
		int min = 0;
		int max = strings.length;
		int choise = random(min, max);
		return strings[choise];
	}

	private static AlertImage random(AlertImage image) {
		String[] urls = new String[]{photo1, photo2, photo3};
		int[] widths = new int[]{512, 576, 650};
		int[] heights = new int[]{341, 384, 433};

		int min = 0;
		int max = urls.length;
		int choise = random(min, max);
		image.setUrl(urls[choise]);
		image.setWidth(widths[choise]);
		image.setHeight(heights[choise]);
		return image;
	}

	private static int random(int min, int max) {
		Random random = new Random();
		return random.nextInt(max - min) + min;
	}

	private static double random(double min, double max) {
		Random random = new Random();
		return min + (max - min) * random.nextDouble();
	}


	private static Observable<Boolean> seedMapObjects(Context context) {
		List<MapObject> mapObjects = new ArrayList<>();
		for (int i = 0; i < 20; i++) {
			mapObjects.add(createMapObject(i * 59849));
		}
		IMapObjectRepository repository = new RequeryMapObjectRepository(context);
		return repository.update(mapObjects)
		                 .toObservable();
	}

	private static MapObject createMapObject(long id) {
		MapObject mapObject = new MapObject();
		mapObject.setId(id);
		mapObject.setTitle("Punto d'interesse " + id);
		mapObject.setDescription("Descrizione " + id);
		mapObject.setTopic(random(new String[]{"camerino", "fabriano", "norcia"}));
		mapObject.setType(random(1, 3));
		createMapPoints(mapObject);
		return mapObject;
	}
}
