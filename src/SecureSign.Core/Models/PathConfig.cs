﻿/**
 * Copyright (c) 2017 Daniel Lo Nigro (Daniel15)
 * 
 * This source code is licensed under the MIT license found in the 
 * LICENSE file in the root directory of this source tree. 
 */

namespace SecureSign.Core.Models
{
	/// <summary>
	/// Defines configuration for various file paths
	/// </summary>
    public class PathConfig
    {
		/// <summary>
		/// The root directory for the SecureSign app
		/// </summary>
		public string Root { get; set; }

		/// <summary>
		/// Gets or sets the path to store encryption keys
		/// </summary>
		public string EncryptionKeys { get; set; }

		/// <summary>
		/// Gets or sets the path to store Authenticode certificates
		/// </summary>
		public string Certificates { get; set; }

		/// <summary>
		/// Gets or sets the path to signtool.exe
		/// </summary>
	    public string SignTool { get; set; } = @"C:\Program Files (x86)\Windows Kits\8.1\bin\x86\signtool.exe";

    }
}
