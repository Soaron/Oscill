PIC = 18f2550
SDCC = sdcc
ARCH = -mpic16 -p$(PIC) --use-non-free

CFLAGS = $(ARCH) -c \
--pstack-model=small \
--fomit-frame-pointer \
--obanksel=2 \
--opt-code-size \
--optimize-cmp

LDFLAGS = $(ARCH) --no-crt -Wl -m -Wl -s,usb.lkr

INCLUDEDIR = 
PROJ = usb-oscope

OBJS = main.o usb.o descr.o

DEP_FILES = .deps/*.P

COMPILE = $(SDCC) $(CFLAGS) $(INCLUDEDIR)

all: $(PROJ).hex

DEPS_MAGIC := $(shell mkdir .deps > /dev/null 2>&1 || :)
-include $(DEP_FILES)

$(OBJS): %o: %c
	@echo '  [CC] $@'; $(COMPILE) -Wp,-MD,.deps/$(*F).P $<

$(PROJ).hex: $(OBJS)
	@echo '  [LD] $@'; $(SDCC) $(LDFLAGS)  -o $(PROJ).hex $(OBJS)

clean:
	@echo '  [CLEAN] $(OBJS) $(PROJ).hex'; rm -f *.o *.asm *.hex *.cod *.lst *.map
	@echo '  [CLEAN] .deps'; rm -fr .deps

flash: $(PROJ).hex
	isc_bootloader -e
	isc_bootloader -w $(PROJ).hex
