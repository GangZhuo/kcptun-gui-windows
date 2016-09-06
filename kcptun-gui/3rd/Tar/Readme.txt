Mon, 16 Nov 2009  09:45

This is a simple TAR library and command-line tool (application).

It is implemented in C#, in the source file Tar.cs.  It requires .NET
3.5 at a minimum. It is licensed under the MS-PL, see the License.txt
file.

If you compile the Tar.cs module with the symbol "EXE" defined (/d:EXE
on the csc.exe command line), then the result will be a console-based
Tar application, much like the one shipped in Unix. Compiled this way,
it has no dependencies on an external Tar dll. This tool can read or
write standard tar files.

If you compile the Tar.cs module with no EXE symbol defined, then the
result will be a Tar dll, Ionic.Tar.dll, that provides a Tar class, that
can then be used from other applications.

The supplied makefile builds both of these targets by default.


Also included in this package is a source module for a VB tar example
application, supplied in TarApp.vb.  When you compile the VB
application, you must reference the Ionic.Tar.dll library. (using
/R:Ionic.Tar.dll on the vbc.exe command line, for example)


The Tar.shfbproj file defines the Sandcastle Helpfile Builder project,
which can be used to produce the .chm file.  To do this, you need
Sandcastle Helpfile Builder, from http://shfb.codeplex.com/ .


The Tar.exe, Ionic.Tar.dll, Ionic.Tar.chm, and VBTarApp.exe targets can be
built from the supplied makefile.



Your Comments are Welcome
---------------------------------

Go to this URL to send a comment:
http://cheeso.members.winisp.net/SendComment.aspx?t=Tar

