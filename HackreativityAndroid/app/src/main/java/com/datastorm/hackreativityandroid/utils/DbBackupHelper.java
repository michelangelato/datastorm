package com.datastorm.hackreativityandroid.utils;

import android.content.Context;
import android.os.Environment;

import com.dadino.quickstart.core.utils.Logs;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStream;


public class DbBackupHelper {

	public static void backupDatabase(Context context) {
		File dir = context.getDatabasePath("default");
		copyFileToDownloadDir(dir);
	}

	private static void copyFileToDownloadDir(File file) {
		Logs.model("Copying file: " + file.getName());
		try {
			//Open your local db as the input stream
			FileInputStream fis = new FileInputStream(file);

			File outFileName = new File(
					Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_DOWNLOADS),
					file.getName() + ".sql");
			//Open the empty db as the output stream
			OutputStream output = new FileOutputStream(outFileName);
			//transfer bytes from the inputfile to the outputfile
			byte[] buffer = new byte[1024];
			int length;
			while ((length = fis.read(buffer)) > 0) {
				output.write(buffer, 0, length);
			}
			//Close the streams
			output.flush();
			output.close();
			fis.close();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}