package com.datastorm.hackreativityandroid.utils;

import com.datastorm.hackreativityandroid.interfaces.PostDeserializable;
import com.datastorm.hackreativityandroid.interfaces.PostSerializable;
import com.datastorm.hackreativityandroid.interfaces.PreSerializable;
import com.google.gson.Gson;
import com.google.gson.TypeAdapter;
import com.google.gson.TypeAdapterFactory;
import com.google.gson.reflect.TypeToken;
import com.google.gson.stream.JsonReader;
import com.google.gson.stream.JsonWriter;

import java.io.IOException;

public class PostProcessingEnabler implements TypeAdapterFactory {

	public <T> TypeAdapter<T> create(Gson gson, TypeToken<T> type) {
		final TypeAdapter<T> delegate = gson.getDelegateAdapter(this, type);

		return new TypeAdapter<T>() {
			public void write(JsonWriter out, T value) throws
					IOException {
				if (value instanceof PreSerializable) {
					((PreSerializable) value).preSerialization();
				}
				delegate.write(out, value);
				if (value instanceof PostSerializable) {
					((PostSerializable) value).postSerialization();
				}
			}

			public T read(JsonReader in) throws
					IOException {
				T obj = delegate.read(in);
				if (obj instanceof PostDeserializable) {
					((PostDeserializable) obj).postDeserialization();
				}
				return obj;
			}
		};
	}
}