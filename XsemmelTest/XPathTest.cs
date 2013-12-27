﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XSemmel.Test
{
    [TestClass]
    public class XPathTest
    {
        [TestMethod]
        public void XTest()
        {
        }
    }
}

#if JAVA
package de.schnitzer.xmlchecker.xpath;

import java.io.File;
import java.io.FileReader;
import java.io.IOException;

import junit.framework.Assert;

import org.junit.Test;

public class XPathTest {
	
	private File xmlFile = new File("test/books.xml");
	
	@Test
	public void allTitles() throws IOException {
		String s = "/bookstore/book/title";
		String ret = new XPath().executeXPath(new FileReader(xmlFile), s);
		
		Assert.assertEquals("<title lang=\"en\">Everyday Italian</title>\n" +
				"<title lang=\"en\">Harry Potter</title>\n" +
				"<title lang=\"en\">XQuery Kick Start</title>\n" +
				"<title lang=\"en\">Learning XML</title>\n",
				ret);
	}

}


#endif